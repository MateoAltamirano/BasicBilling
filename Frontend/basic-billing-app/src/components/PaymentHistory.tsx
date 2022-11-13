import { Flex, Select, Text, useToast } from '@chakra-ui/react';
import { CATEGORY } from '../utils/constants';
import { useBasicBillingStore } from '../utils/useBasicBillingStore';
import ClientBillCard from './ClientBillCard';
import EmptyList from './EmptyList';

const PaymentHistory = () => {
  const billsByCategory = useBasicBillingStore(
    (state) => state.billsByCategory
  );

  const fetchBillsByCategory = useBasicBillingStore(
    (state) => state.fetchBillsByCategory
  );

  const toast = useToast();

  const handleCategoryChange = async (category: string) => {
    const errors = await fetchBillsByCategory(category);
    if (errors) {
      toast({
        title: errors.type,
        description: errors.details.join(', '),
        status: 'error',
        duration: 3000,
      });
    }
  };

  return (
    <Flex h={'100%'} w={'30rem'} flexDir={'column'} overflow={'auto'}>
      <Select
        placeholder={'Select category'}
        onChange={({ target }) => handleCategoryChange(target.value)}
      >
        {Object.values(CATEGORY).map((category, index) => (
          <option key={index} value={category}>
            {category}
          </option>
        ))}
      </Select>
      {billsByCategory.length > 0 ? (
        billsByCategory.map((bill) => (
          <ClientBillCard key={bill.id} id={bill.id} status={bill.status} />
        ))
      ) : (
        <EmptyList message={'Choose a category'} />
      )}
    </Flex>
  );
};

export default PaymentHistory;
