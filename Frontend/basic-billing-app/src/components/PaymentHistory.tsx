import { Flex, Select, Text, useToast } from '@chakra-ui/react';
import { CATEGORY } from '../utils/constants';
import { useBasicBillingStore } from '../utils/useBasicBillingStore';
import { FiInbox } from 'react-icons/fi';
import ClientBillCard from './ClientBillCard';

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
    <Flex h={'100%'} w={'100%'} flexDir={'column'} overflow={'auto'}>
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
        <Flex
          flexDir={'column'}
          h={'100%'}
          w={'100%'}
          justifyContent={'center'}
          alignItems={'center'}
        >
          <FiInbox size={'10rem'} color={'#CBD5E0'} />
          <Text fontSize={'1.5rem'} color={'#CBD5E0'}>
            {'Choose a category'}
          </Text>
        </Flex>
      )}
    </Flex>
  );
};

export default PaymentHistory;
