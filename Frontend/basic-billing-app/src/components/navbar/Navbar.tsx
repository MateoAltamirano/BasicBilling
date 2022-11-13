import { Divider, Flex, Image, TabList, Text } from '@chakra-ui/react';
import { NAVBAR_WIDTH, SECTION } from '../../utils/constants';
import { FiClock, FiCalendar } from 'react-icons/fi';
import NavbarButton from './NavbarButton';

const Navbar = () => {
  return (
    <Flex
      bgColor={'gray.100'}
      flexDir={'column'}
      h={'100%'}
      p={'1.5rem'}
      shadow={'lg'}
      w={`${NAVBAR_WIDTH}px`}
    >
      <Flex alignItems={'center'}>
        <Image src={'/vite.svg'} width={'3rem'} />
        <Text ml={'0.5rem'} fontSize={'1.5rem'} fontWeight={'semibold'}>
          {'Basic Billing'}
        </Text>
      </Flex>
      <Divider m={'1rem 0'} />
      <TabList border={'none'} display={'flex'} flexDir={'column'}>
        <NavbarButton icon={<FiClock size={'1.25rem'} />}>
          {SECTION.PaymentHistory}
        </NavbarButton>
        <NavbarButton icon={<FiCalendar size={'1.25rem'} />}>
          {SECTION.PendingBills}
        </NavbarButton>
      </TabList>
    </Flex>
  );
};

export default Navbar;
